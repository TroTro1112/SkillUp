//
// Unityちゃん用の三人称カメラ
// 
// 2013/06/07 N.Kobyasahi
//
using UnityEngine;
using System.Collections;

namespace UnityChan
{
	public class ThirdPersonCamera : MonoBehaviour
	{
		public float smooth = 3f;		// カメラモーションのスムーズ化用変数
		Transform standardPos;			// the usual position for the camera, specified by a transform in the game
		Transform frontPos;			// Front Camera locater
		Transform jumpPos;			// Jump Camera locater
	
		// スムーズに繋がない時（クイック切り替え）用のブーリアンフラグ
		bool bQuickSwitch = false;	//Change Camera Position Quickly
	
	
		void Start ()
		{
			// 各参照の初期化
			standardPos = GameObject.Find ("CamPos").transform;
		
			if (GameObject.Find ("FrontPos"))
				frontPos = GameObject.Find ("FrontPos").transform;

			if (GameObject.Find ("JumpPos"))
				jumpPos = GameObject.Find ("JumpPos").transform;

			//カメラをスタートする
			transform.position = standardPos.position;	// カメラ位置
			transform.forward = standardPos.forward;	// カメラ向き
		}

		void FixedUpdate()  // このカメラ切り替えはFixedUpdate()内でないと正常に動かない
		{
			// return the camera to standard position and direction
			setCameraPositionNormalView();
		}

		// カメラを標準の位置と方向に（クイックチェンジ）
		void setCameraPositionNormalView()
		{
			transform.position = standardPos.position;
			transform.forward = standardPos.forward;
			bQuickSwitch = false;
		}
	}
}