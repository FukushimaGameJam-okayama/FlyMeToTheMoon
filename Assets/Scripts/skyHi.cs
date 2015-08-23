using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class skyHi : MonoBehaviour {
	public Sprite[] Numbers = new Sprite[10];//Inspectorから指定.
	public Image[] Figures = new Image[6];//Inspectorから指定.
	public GameObject SuccessResult;
	private int[] FigureSeparation = new int[6];//桁分離した高度.
	const float moonhight =120;

	public BalloonController BalloonS;
	void Update () {
		NumberChange ((int)(gameObject.transform.position.y / moonhight * 384400 ));
	}
	private void NumberChange(int tmpValue){
		if (tmpValue > 0) {
			FigureSeparation [5] = tmpValue / 100000;
			FigureSeparation [4] = (tmpValue - FigureSeparation [5] * 100000) / 10000;
			FigureSeparation [3] = (tmpValue - FigureSeparation [5] * 100000 - FigureSeparation [4] * 10000) / 1000;
			FigureSeparation [2] = (tmpValue - FigureSeparation [5] * 100000 - FigureSeparation [4] * 10000 - FigureSeparation [3] * 1000) / 100;
			FigureSeparation [1] = (tmpValue - FigureSeparation [5] * 100000 - FigureSeparation [4] * 10000 - FigureSeparation [3] * 1000 - FigureSeparation [2] * 100) / 10;
			FigureSeparation [0] = (tmpValue - FigureSeparation [5] * 100000 - FigureSeparation [4] * 10000 - FigureSeparation [3] * 1000 - FigureSeparation [2] * 100 - FigureSeparation [1] * 10);
			if (FigureSeparation [5] > 0)
				Figures [5].gameObject.SetActive (true);
			if (FigureSeparation [4] > 0)
				Figures [4].gameObject.SetActive (true);
			if (FigureSeparation [3] > 0)
				Figures [3].gameObject.SetActive (true);
			if (FigureSeparation [2] > 0)
				Figures [2].gameObject.SetActive (true);
			if (FigureSeparation [1] > 0)
				Figures [1].gameObject.SetActive (true);

			Figures [0].sprite = Numbers [FigureSeparation [0]];
			Figures [1].sprite = Numbers [FigureSeparation [1]];
			Figures [2].sprite = Numbers [FigureSeparation [2]];
			Figures [3].sprite = Numbers [FigureSeparation [3]];
			Figures [4].sprite = Numbers [FigureSeparation [4]];
			Figures [5].sprite = Numbers [FigureSeparation [5]];
			if(tmpValue>384400){
				SuccessResult.SetActive(true);
				BalloonS.GameSuccess();
			}
		}
	}
}
