import MapController from "./MapController";

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
    @property(cc.Float)
    moveSpeedX = 0;
    // onLoad () {}

    start () {
        this.node.once(cc.Node.EventType.TOUCH_START, () => {
            this.node.runAction(cc.moveBy(this.moveCenterTime, new cc.Vec2(0, 600)));
            cc.delayTime(this.moveCenterTime);
            this.node.on(cc.Node.EventType.TOUCH_START, this.changeForward, this);
        }, this);
    }

    changeForward() {
        this.bLeft = !this.bLeft;
        this.node.rotation = this.bLeft ? -this.changeRotate : this.changeRotate;
        this.moveSpeedX = MapController.instance.moveSpeed.y / Math.tan(this.changeRotate);
    }

    // update (dt) {}
}
