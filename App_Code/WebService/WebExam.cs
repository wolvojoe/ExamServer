using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WebExam
/// </summary>
public class WebExam
{
    public int ExamID;
    public String ExamName;
    public DateTime ExamDateCreated;
    public bool ExamActive;
    public String ExamDescription;
    public DateTime ExamOpenDate;
    public bool ExamOpenDateEnabled;
    public DateTime ExamClosedDate;
    public bool ExamClosedDateEnabled;
    public int ExamTimeLimit;
    public bool ExamTimeLimitEnabled;
    public int ExamAttemptsAllowed;
    public bool ExamQuestionsOrdered;
    public bool ExamShuffleAnswers;
    public bool ExamLearningMode;
    public bool ExamPassword;

    public int NumberOfQuestions;

	public WebExam()
	{

	}

    public void GetExamByID()
    {
        var GetExam = new Exam();

        GetExam.ExamID = ExamID;
        GetExam.SelectExamByID();

        ExamID = GetExam.ExamID;
        ExamName = GetExam.ExamName;
        ExamDateCreated = GetExam.ExamDateCreated;
        ExamActive = GetExam.ExamActive;
        ExamDescription = GetExam.ExamDescription;

        ExamOpenDate = GetExam.ExamOpenDate;
        ExamClosedDate = GetExam.ExamClosedDate;
        ExamClosedDateEnabled = GetExam.ExamClosedDateEnabled;
        ExamTimeLimit = GetExam.ExamTimeLimit;
        ExamTimeLimitEnabled = GetExam.ExamTimeLimitEnabled;
        ExamAttemptsAllowed = GetExam.ExamAttemptsAllowed;
        ExamQuestionsOrdered = GetExam.ExamQuestionsOrdered;
        ExamShuffleAnswers = GetExam.ExamShuffleAnswers;
        ExamLearningMode = GetExam.ExamLearningMode;

        if (GetExam.ExamPassword.Length > 0)
        {
            ExamPassword = true;
        }
        else
        {
            ExamPassword = false;
        }

    }
}