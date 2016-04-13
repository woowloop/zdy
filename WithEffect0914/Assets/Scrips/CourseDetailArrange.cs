using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace CourseDetail
{
    public class HisPicInf
    {
        public static HisPicInf _Instance=null;
        public class CDetail
        {
            public class CArrList
            {
                public string logo;
                public int wrongcount;
                public string trainid;
                public int completecount;
                public string recordtime;
                public int courseid;
                public string calorie;
                public string coursename;
            }
            public bool lastPage;
            public int pageSize;
            public int pageNumber;
            public List<CArrList> list;
            public bool firstPage;
            public int totalRow;
            public int totalPage;
        }
        public CDetail detail;
        public string description;
        public string code;
        public HisPicInf()
        {
            _Instance = this;
        }
    }
    public class CourseDetailArr_2
    {
        public class Detail_2
        {
            public int id;
            public string logo;
            public string coursedescrip;
            public string partid;
            public string typeid;
            public int grade;
            public string gender;
            public string coachid;
            public string calorie;
            public string video;
            public string coursename;
            public string movecourseurl;
        }
        public List<Detail_2> detail;
        public string description;
        public string code;
        public static CourseDetailArr_2 _Instance = null;
        public bool IsInitOk = false;
        public CourseDetailArr_2()
        {
            _Instance = this;
        }
    }
    public class CourseType
    {
        public class DetailType
        {
            public int id;
            public string logo;
            public string name;
        }
        public List<DetailType> detail;
        public string description;
        public string code;
        public static CourseType _Instance = null;
        public bool IsInitOk = false;
        public CourseType()
        {
            _Instance = this;
        }
    }
    public class CourseDetailArr
    {
        public List<Detail> detail;
        public string description;
        public string code;
        int index = 0;

        public bool IsInitOk = false;
        static CourseDetailArr _instance;

        public CourseDetailArr()
        {
            _instance = this;
        }
        public static CourseDetailArr Instance
        {
            get { return _instance; }
        }
        public bool Push(ref int courseNum)
        {
            int len_detail = detail.Count;
            if (index >= len_detail)
                return false;
            courseNum = detail[index].coursePush.courseid;
            index++;

            return true;
        }

        public bool CyclePush(ref int courseNum)
        {
            if (detail == null)
                return false;
            int len_detail = detail.Count;
            if (len_detail <= 0)
                return false;
            courseNum = detail[index].coursePush.courseid;
            index = ++index % detail.Count;
            Debug.Log(index);
            return true;
        }
    }

    public class Detail
    {
        public class Trains
        {
            public int wrongcount;
            public int courseid;
            public string trainid;
            public int completecount;
            public string courselogo;
            public string recordtime;
            public string calorie;
            public string coursename;
            
        }
        public List<Trains> trains;
        public CoursePush coursePush;

    }


    public class CoursePush
    {
        public string pushtime;
        public int id;
        public string videourl;
        public string courselogo;
        public int courseid;
        public string trainid;
        public string traintime;
        public string coursename;
        public bool finished;
        public double calorie;
        public int traincount;
        public int alreadytraincount;
        public string coursedescrip;
    }

}
