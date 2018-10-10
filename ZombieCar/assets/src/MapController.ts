
const {ccclass, property} = cc._decorator;

@ccclass
export default class MapController extends cc.Component {

    @property(cc.Node)
    map1: cc.Node = null;
    @property(cc.Node)
    map2: cc.Node = null;
    @property(cc.Float)
    ySpeed = 0;

    private srcPos: cc.Vec2 = null;
    private tarPos: cc.Vec2 = null;

    start () {
        this.srcPos = this.map2.position;
        this.tarPos = this.map1.position.mul(2).sub(this.srcPos);
    }
    run() {

    }
    static instance: MapController = null;
    onLoad() {
        MapController.instance = this;
    }
}
