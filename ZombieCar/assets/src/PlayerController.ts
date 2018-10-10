
const {ccclass, property} = cc._decorator;

@ccclass
export default class PlayerController extends cc.Component {

    // onLoad () {}
    @property(cc.Node)
    touchLeft: cc.Node = null;
    @property(cc.Node)
    touchRight: cc.Node = null;
    @property(cc.Float)
    initialVelocity = 0;
    @property(cc.Float)
    acceleration = 1;
    
    start () {

    }

    run() {

    }
    static instance: PlayerController = null;
    onLoad() {
        PlayerController.instance = this;
    }
}
