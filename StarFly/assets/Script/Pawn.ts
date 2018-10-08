import MapController from "./MapController";
import GameManager from "./GameManager";

// Learn TypeScript:
//  - [Chinese] http://docs.cocos.com/creator/manual/zh/scripting/typescript.html
//  - [English] http://www.cocos2d-x.org/docs/creator/manual/en/scripting/typescript.html
// Learn Attribute:
//  - [Chinese] http://docs.cocos.com/creator/manual/zh/scripting/reference/attributes.html
//  - [English] http://www.cocos2d-x.org/docs/creator/manual/en/scripting/reference/attributes.html
// Learn life-cycle callbacks:
//  - [Chinese] http://docs.cocos.com/creator/manual/zh/scripting/life-cycle-callbacks.html
//  - [English] http://www.cocos2d-x.org/docs/creator/manual/en/scripting/life-cycle-callbacks.html

const {ccclass, property} = cc._decorator;

export let PawnType = cc.Enum({
    PawnType_Block:0,
    PawnType_Score:1,
    PawnType_Die:2
});

@ccclass
export default class Pawn extends cc.Component {

    // LIFE-CYCLE CALLBACKS:
    @property({type:cc.Enum(PawnType)})
    type = 0;

    sprite: cc.Sprite = null;
    // onLoad () {}

    start () {
    }

    init(type: number, x: number) {
        this.sprite = this.getComponent(cc.Sprite);
        this.sprite.spriteFrame = MapController.instance.spriteArr[type];
        this.type = type;
        this.node.runAction(
            cc.sequence(
                cc.moveTo(
                    5, new cc.Vec2(x, -GameManager.instance.screenSize.height)
                ),
                cc.callFunc(this.moveEndCall, this)
            )
        );
    }

    onCollisionEnter(other: cc.Collider, self: cc.Collider) {
        if(other.tag == 0) {
            switch(this.type) {
                case PawnType.PawnType_Die:
                case PawnType.PawnType_Block:
                GameManager.instance.gameover();
                break;
                case PawnType.PawnType_Score:
                this.moveEndCall();
                break;
            }
        }
    }

    moveEndCall() {
        this.node.active = false;
        MapController.instance.pawnPool.put(this.node);
    }
    // update (dt) {}
}

