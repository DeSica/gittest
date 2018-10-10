import MapController from "./MapController";
import PlayerController from "./PlayerController";

const {ccclass, property} = cc._decorator;

@ccclass
export default class GameManager extends cc.Component {

    start () {

    }

    update (dt) {
        MapController.instance.run();
        PlayerController.instance.run();
    }

    static instance: GameManager = null;
    onLoad() {
        GameManager.instance = this;
    }
}
