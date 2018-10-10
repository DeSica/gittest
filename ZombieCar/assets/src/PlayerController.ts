
const {ccclass, property} = cc._decorator;

@ccclass
export default class PlayerController extends cc.Component {

    // onLoad () {}
    @property(cc.Node)
    player: cc.Node = null
    @property(cc.Node)
    touchLeft: cc.Node = null;
    @property(cc.Node)
    touchRight: cc.Node = null;
    @property(cc.Vec2)
    initialVelocity: cc.Vec2 = cc.Vec2.ZERO;
    @property(cc.Vec2)
    acceleration: cc.Vec2 = new cc.Vec2(1, 0);
    @property(cc.Float) 
    friction = 1;

    bMoveLeft: boolean = false;
    bMoveRight: boolean = false;
    curAccel: cc.Vec2 = cc.Vec2.ZERO;
    curVeloc: cc.Vec2 = cc.Vec2.ZERO;
    start () {
        this.touchLeft.on(cc.Node.EventType.TOUCH_START, () => {this.bMoveLeft = true}, this);
        this.touchLeft.on(cc.Node.EventType.TOUCH_END, () => {this.bMoveLeft = false}, this);
        this.touchLeft.on(cc.Node.EventType.TOUCH_CANCEL, () => {this.bMoveLeft = false}, this);
        this.touchRight.on(cc.Node.EventType.TOUCH_START, () => {this.bMoveRight = true}, this);
        this.touchRight.on(cc.Node.EventType.TOUCH_END, () => {this.bMoveRight = false}, this);
        this.touchRight.on(cc.Node.EventType.TOUCH_CANCEL, () => {this.bMoveRight = false}, this);
    }

    run() {
        if(this.bMoveLeft != this.bMoveRight) {
            if(this.bMoveLeft) {
                this.curVeloc = this.curVeloc.sub(this.acceleration);
            } else {
                this.curVeloc = this.curVeloc.add(this.acceleration);
            }
        // } else if(this.curVeloc.mag() > 0){
        //     this.curVeloc = this.curVeloc.add(this.curVeloc.negSelf().normalize().mul(this.friction));
        // }
        this.player.position = this.player.position.add(this.curVeloc);
    }

    static instance: PlayerController = null;
    onLoad() {
        PlayerController.instance = this;
    }
}
