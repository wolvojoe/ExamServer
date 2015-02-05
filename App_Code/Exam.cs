using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Exam
/// </summary>
public class Exam
{

    public int pkExam_ID;
    public String Exam_Name;
    public DateTime Exam_Date_Created;
    public int Exam_Active;
    public String Exam_Description;
    public DateTime Exam_Open_Date;
    public bool Exam_Open_Date_Enabled;
    public DateTime Exam_Closed_Date;
    public bool Exam_Closed_Date_Enabled;
    public DateTime Exam_Time_Limit;
    public bool Exam_Time_Limit_Enabled;
    public int Exam_Attempts_Allowed;
    public bool Exam_Questions_Ordered;
    public bool Exam_Shuffle_Answers;
    public bool Exam_Learning_Mode;
    public String Exam_Password;


	public Exam()
	{

	}
}