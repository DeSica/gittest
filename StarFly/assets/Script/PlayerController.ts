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

@ccclass
export default class PlayerController extends cc.Component {

    // LIFE-CYCLE CALLBACKS:
    @property(cc.Float)
    moveCenterTime = 2;
    @property(cc.Float)
    changeRotate = 45;
    @property(cc.Float)
    bLeft: boolean = true;
    @property(cc.Vec2)
    moveSpeed: cc.Vec2 = cc.Vec2.ZERO;

    screenWidth = 0;
    static instance: PlayerController = null;
    onLoad () {
        PlayerController.instance = this;
    }

    start () {
        this.screenWidth = GameManager.instance.screenSize.width;
    }

    changeDir() {
        this.bLeft = !this.bLeft;
        this.node.rotation = this.bLeft ? -this.changeRotate : this.changeRotate;
        this.moveSpeed = new cc.Vec2(-MapController.instance.moveSpeed.y / Math.tan(this.node.rotation), 0); 
    }
    run() {
        this.node.position = this.node.position.add(this.moveSpeed);
        if(this.node.position.x < -this.screenWidth / 2 && this.bLeft
        || this.node.position.x > this.screenWidth / 2 && !this.bLeft) {
            this.changeDir();
        }
    }
}
