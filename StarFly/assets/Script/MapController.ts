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
export default class MapController extends cc.Component {

    // @property(cc.Label)
    // label: cc.Label = null;

    // @property
    // text: string = 'hello';

    // LIFE-CYCLE CALLBACKS:

    @property(cc.Node)
    bg1: cc.Node = null;
    @property(cc.Node)
    bg2: cc.Node = null;
    @property(cc.Vec2)
    moveSpeed: cc.Vec2 = null;

    static instance: MapController = null;
    onLoad () {
        MapController.instance = this;
    }

    start () {
    }

    public runMap() {
        this.bg1.position = this.bg1.position.add(this.moveSpeed);
        this.bg2.position = this.bg2.position.add(this.moveSpeed);
        if(this.bg1.y <= -this.bg1.height / 2) {
            this.bg1.y = this.bg1.height * 1.5;
        }
        if(this.bg2.y <= -this.bg2.height / 2) {
            this.bg2.y = this.bg2.height * 1.5;
        }
    }
    // update (dt) {}
}
