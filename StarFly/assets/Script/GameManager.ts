import MapController from "./MapController";
import PlayerController from "./PlayerController";

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
export default class GameManager extends cc.Component {

    // LIFE-CYCLE CALLBACKS:
    @property(cc.Label)
    playerScoreLabel: cc.Label = null;

    playerScore = 0;
    screenSize: cc.Size = null;
    static instance: GameManager = null;
    onLoad () {
        GameManager.instance = this;
        this.screenSize = cc.winSize;
        cc.director.getCollisionManager().enabled = true;
    }

    start () {
        this.node.on(cc.Node.EventType.TOUCH_END, this.clickCanvas, this);
    }
    clickCanvas() {
        PlayerController.instance.changeDir();
    }
    update (dt) {
        MapController.instance.run();
        PlayerController.instance.run();
    }
    gameover() {
        cc.director.loadScene('Game');
    }
    addScore(add: number) {
        this.playerScore += add;
        this.playerScoreLabel.string = String(this.playerScore);
    }
}
