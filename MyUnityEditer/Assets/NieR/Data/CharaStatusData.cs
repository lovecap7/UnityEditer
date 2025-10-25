using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StatusData;

public class CharaStatusData : MonoBehaviour
{
    [SerializeField]
    //UŒ‚‚Å‚Ğ‚é‚Ü‚È‚¢‹­‚³
    public enum Armor : int
    {
        Light = 0,
		Middle = 1,
		Heavy = 2,
		Heaviest = 3,
	};  
    public int      m_hp;       //Å‘å‘Ì—Í
    public int      m_at;       //UŒ‚—Í
    public int      m_df;       //–hŒä—Í
    public float    m_ms;       //ˆÚ“®‘¬“x
    public float    m_jp;       //ƒWƒƒƒ“ƒv—Í
    public Armor    m_ar;       //ƒA[ƒ}[
    public float m_searchRange;//õ“G”ÍˆÍ
    public float m_searchAngle; //õ“GƒAƒ“ƒOƒ‹
    public float m_meleeAttackRange;	//‹ßÚUŒ‚‹——£
}
