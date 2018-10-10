import MapController from "./MapController";

const {ccclass, property} = cc._decorator;

@ccclass
export default class GameManager extends cc.Component {

    start () {

    }

    update (dt) {
        MapController.instance.run();
    }
    
    static instance: GameManager = null;
    onLoad() {
        GameManager.instance = this;
    }
}
