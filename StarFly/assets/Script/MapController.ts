import GameManager from "./GameManager";
import Pawn from "./Pawn";

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

    @property(cc.Node)
    bg1: cc.Node = null;
    @property(cc.Node)
    bg2: cc.Node = null;
    @property(cc.Node)
    spawn: cc.Node = null;
    @property(cc.Prefab)
    pawnPrefab: cc.Prefab = null;
    @property(cc.Vec2)
    moveSpeed: cc.Vec2 = cc.Vec2.ZERO;
    @property([cc.SpriteFrame])
    spriteArr: cc.SpriteFrame[] = [];
    @property(cc.Integer)
    pawnPoolInitNum = 10;
    @property(cc.Integer)
    spawnCD = 1;

    spwanLock = false;
    rateArr = [0.01, 0.02, 0.03];
    prefabPawnArrData = [
        [{type: 0, x: 40, y: 0},{type: 0, x: 130, y: 0},{type: 0, x: 220, y: 0}],
        [{type: 1, x: 40, y: 40},{type: 1, x: 130, y: 130},{type: 1, x: 220, y: 220}],
        [{type: 2, x: 300, y: 40},{type: 2, x: 300, y: 130},{type: 2, x: 300, y: 220}],
    ]
    pawnPool: cc.NodePool = null;
    static instance: MapController = null;
    onLoad () {
        MapController.instance = this;
    }

    start () {
        this.pawnPool = new cc.NodePool();
        for(let i = 0; i < this.pawnPoolInitNum; ++i) {
            let pawn = cc.instantiate(this.pawnPrefab);
            pawn.active = false;
            this.pawnPool.put(pawn);
        }
    }

    run() {
        GameManager.instance.addScore(1);
        this.updateMap();
        this.updatePawn();
    }

    updateMap() {
        this.bg1.position = this.bg1.position.add(this.moveSpeed);
        this.bg2.position = this.bg2.position.add(this.moveSpeed);
        if(this.bg1.y <= -this.bg1.height / 2) {
            this.bg1.y = this.bg1.height * 1.5;
        }
        if(this.bg2.y <= -this.bg2.height / 2) {
            this.bg2.y = this.bg2.height * 1.5;
        }
    }

    updatePawn() {
        if(this.spwanLock) {
            return;
        }
        let randomNum = Math.random() * 5;
        for(let i = 0; i < this.rateArr.length; ++i) {
            if(this.rateArr[i] > randomNum) {
                for(let j = 0; j < this.prefabPawnArrData[i].length; ++j) {
                    let data = this.prefabPawnArrData[i][j];
                    let pawn = this.createPawn();
                    pawn.active = true;
                    pawn.setParent(this.spawn);
                    pawn.setPosition(data.x, data.y);
                    pawn.getComponent(Pawn).init(data.type, data.x, data.y);
                }
                this.spwanLock = true;
                this.schedule(() => { this.spwanLock = false; }, this.spawnCD);
                break;
            }
        }
    }

    createPawn() {
        if(this.pawnPool.size() > 0) {
            return this.pawnPool.get();
        } else {
            return cc.instantiate(this.pawnPrefab);
        }   
    }
    // update (dt) {}
}
