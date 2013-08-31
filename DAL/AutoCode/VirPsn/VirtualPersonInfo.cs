using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZHY.DAL
{
	/// <summary>
	/// 数据访问类:VirtualPersonInfo
	/// </summary>
	public partial class VirtualPersonInfo
	{
		public VirtualPersonInfo()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int VPID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from VirtualPersonInfo");
			strSql.Append(" where VPID=@VPID");
			SqlParameter[] parameters = {
					new SqlParameter("@VPID", SqlDbType.Int,4)
			};
			parameters[0].Value = VPID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZHY.Model.VirtualPersonInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into VirtualPersonInfo(");
			strSql.Append("VPFullName,VPFirstName,VPMiddleName,VPLastName,VPSex,VPBirthday,VPMail,VPNickName,VPPassword,VPAge,VPCollege,VPOccupation,VPSsn,VPHeight,VPWeight,VPBloodType,VPState,VPCity,VPStreet,VPZip,VPPhone,VPVisa,VPVisaExpirDate,VPCVV2,VPBank,VPRoutingNumber,VPBankAcct,VPMasterCard,VPMExpirDate,VPMCVC2,VPSite,VPNationality,CreateAt,CreateBy,UpdateDT,UpdateBy)");
			strSql.Append(" values (");
			strSql.Append("@VPFullName,@VPFirstName,@VPMiddleName,@VPLastName,@VPSex,@VPBirthday,@VPMail,@VPNickName,@VPPassword,@VPAge,@VPCollege,@VPOccupation,@VPSsn,@VPHeight,@VPWeight,@VPBloodType,@VPState,@VPCity,@VPStreet,@VPZip,@VPPhone,@VPVisa,@VPVisaExpirDate,@VPCVV2,@VPBank,@VPRoutingNumber,@VPBankAcct,@VPMasterCard,@VPMExpirDate,@VPMCVC2,@VPSite,@VPNationality,@CreateAt,@CreateBy,@UpdateDT,@UpdateBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@VPFullName", SqlDbType.VarChar,32),
					new SqlParameter("@VPFirstName", SqlDbType.VarChar,16),
					new SqlParameter("@VPMiddleName", SqlDbType.VarChar,16),
					new SqlParameter("@VPLastName", SqlDbType.VarChar,16),
					new SqlParameter("@VPSex", SqlDbType.VarChar,8),
					new SqlParameter("@VPBirthday", SqlDbType.DateTime),
					new SqlParameter("@VPMail", SqlDbType.VarChar,64),
					new SqlParameter("@VPNickName", SqlDbType.VarChar,64),
					new SqlParameter("@VPPassword", SqlDbType.VarChar,32),
					new SqlParameter("@VPAge", SqlDbType.Int,4),
					new SqlParameter("@VPCollege", SqlDbType.VarChar,128),
					new SqlParameter("@VPOccupation", SqlDbType.VarChar,64),
					new SqlParameter("@VPSsn", SqlDbType.VarChar,16),
					new SqlParameter("@VPHeight", SqlDbType.Int,4),
					new SqlParameter("@VPWeight", SqlDbType.Int,4),
					new SqlParameter("@VPBloodType", SqlDbType.VarChar,8),
					new SqlParameter("@VPState", SqlDbType.VarChar,8),
					new SqlParameter("@VPCity", SqlDbType.VarChar,16),
					new SqlParameter("@VPStreet", SqlDbType.VarChar,32),
					new SqlParameter("@VPZip", SqlDbType.Int,4),
					new SqlParameter("@VPPhone", SqlDbType.VarChar,16),
					new SqlParameter("@VPVisa", SqlDbType.Int,4),
					new SqlParameter("@VPVisaExpirDate", SqlDbType.DateTime),
					new SqlParameter("@VPCVV2", SqlDbType.Int,4),
					new SqlParameter("@VPBank", SqlDbType.VarChar,32),
					new SqlParameter("@VPRoutingNumber", SqlDbType.Int,4),
					new SqlParameter("@VPBankAcct", SqlDbType.Int,4),
					new SqlParameter("@VPMasterCard", SqlDbType.Int,4),
					new SqlParameter("@VPMExpirDate", SqlDbType.DateTime),
					new SqlParameter("@VPMCVC2", SqlDbType.Int,4),
					new SqlParameter("@VPSite", SqlDbType.VarChar,32),
					new SqlParameter("@VPNationality", SqlDbType.VarChar,32),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64)};
			parameters[0].Value = model.VPFullName;
			parameters[1].Value = model.VPFirstName;
			parameters[2].Value = model.VPMiddleName;
			parameters[3].Value = model.VPLastName;
			parameters[4].Value = model.VPSex;
			parameters[5].Value = model.VPBirthday;
			parameters[6].Value = model.VPMail;
			parameters[7].Value = model.VPNickName;
			parameters[8].Value = model.VPPassword;
			parameters[9].Value = model.VPAge;
			parameters[10].Value = model.VPCollege;
			parameters[11].Value = model.VPOccupation;
			parameters[12].Value = model.VPSsn;
			parameters[13].Value = model.VPHeight;
			parameters[14].Value = model.VPWeight;
			parameters[15].Value = model.VPBloodType;
			parameters[16].Value = model.VPState;
			parameters[17].Value = model.VPCity;
			parameters[18].Value = model.VPStreet;
			parameters[19].Value = model.VPZip;
			parameters[20].Value = model.VPPhone;
			parameters[21].Value = model.VPVisa;
			parameters[22].Value = model.VPVisaExpirDate;
			parameters[23].Value = model.VPCVV2;
			parameters[24].Value = model.VPBank;
			parameters[25].Value = model.VPRoutingNumber;
			parameters[26].Value = model.VPBankAcct;
			parameters[27].Value = model.VPMasterCard;
			parameters[28].Value = model.VPMExpirDate;
			parameters[29].Value = model.VPMCVC2;
			parameters[30].Value = model.VPSite;
			parameters[31].Value = model.VPNationality;
			parameters[32].Value = model.CreateAt;
			parameters[33].Value = model.CreateBy;
			parameters[34].Value = model.UpdateDT;
			parameters[35].Value = model.UpdateBy;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZHY.Model.VirtualPersonInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update VirtualPersonInfo set ");
			strSql.Append("VPFullName=@VPFullName,");
			strSql.Append("VPFirstName=@VPFirstName,");
			strSql.Append("VPMiddleName=@VPMiddleName,");
			strSql.Append("VPLastName=@VPLastName,");
			strSql.Append("VPSex=@VPSex,");
			strSql.Append("VPBirthday=@VPBirthday,");
			strSql.Append("VPMail=@VPMail,");
			strSql.Append("VPNickName=@VPNickName,");
			strSql.Append("VPPassword=@VPPassword,");
			strSql.Append("VPAge=@VPAge,");
			strSql.Append("VPCollege=@VPCollege,");
			strSql.Append("VPOccupation=@VPOccupation,");
			strSql.Append("VPSsn=@VPSsn,");
			strSql.Append("VPHeight=@VPHeight,");
			strSql.Append("VPWeight=@VPWeight,");
			strSql.Append("VPBloodType=@VPBloodType,");
			strSql.Append("VPState=@VPState,");
			strSql.Append("VPCity=@VPCity,");
			strSql.Append("VPStreet=@VPStreet,");
			strSql.Append("VPZip=@VPZip,");
			strSql.Append("VPPhone=@VPPhone,");
			strSql.Append("VPVisa=@VPVisa,");
			strSql.Append("VPVisaExpirDate=@VPVisaExpirDate,");
			strSql.Append("VPCVV2=@VPCVV2,");
			strSql.Append("VPBank=@VPBank,");
			strSql.Append("VPRoutingNumber=@VPRoutingNumber,");
			strSql.Append("VPBankAcct=@VPBankAcct,");
			strSql.Append("VPMasterCard=@VPMasterCard,");
			strSql.Append("VPMExpirDate=@VPMExpirDate,");
			strSql.Append("VPMCVC2=@VPMCVC2,");
			strSql.Append("VPSite=@VPSite,");
			strSql.Append("VPNationality=@VPNationality,");
			strSql.Append("CreateAt=@CreateAt,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("UpdateDT=@UpdateDT,");
			strSql.Append("UpdateBy=@UpdateBy");
			strSql.Append(" where VPID=@VPID");
			SqlParameter[] parameters = {
					new SqlParameter("@VPFullName", SqlDbType.VarChar,32),
					new SqlParameter("@VPFirstName", SqlDbType.VarChar,16),
					new SqlParameter("@VPMiddleName", SqlDbType.VarChar,16),
					new SqlParameter("@VPLastName", SqlDbType.VarChar,16),
					new SqlParameter("@VPSex", SqlDbType.VarChar,8),
					new SqlParameter("@VPBirthday", SqlDbType.DateTime),
					new SqlParameter("@VPMail", SqlDbType.VarChar,64),
					new SqlParameter("@VPNickName", SqlDbType.VarChar,64),
					new SqlParameter("@VPPassword", SqlDbType.VarChar,32),
					new SqlParameter("@VPAge", SqlDbType.Int,4),
					new SqlParameter("@VPCollege", SqlDbType.VarChar,128),
					new SqlParameter("@VPOccupation", SqlDbType.VarChar,64),
					new SqlParameter("@VPSsn", SqlDbType.VarChar,16),
					new SqlParameter("@VPHeight", SqlDbType.Int,4),
					new SqlParameter("@VPWeight", SqlDbType.Int,4),
					new SqlParameter("@VPBloodType", SqlDbType.VarChar,8),
					new SqlParameter("@VPState", SqlDbType.VarChar,8),
					new SqlParameter("@VPCity", SqlDbType.VarChar,16),
					new SqlParameter("@VPStreet", SqlDbType.VarChar,32),
					new SqlParameter("@VPZip", SqlDbType.Int,4),
					new SqlParameter("@VPPhone", SqlDbType.VarChar,16),
					new SqlParameter("@VPVisa", SqlDbType.Int,4),
					new SqlParameter("@VPVisaExpirDate", SqlDbType.DateTime),
					new SqlParameter("@VPCVV2", SqlDbType.Int,4),
					new SqlParameter("@VPBank", SqlDbType.VarChar,32),
					new SqlParameter("@VPRoutingNumber", SqlDbType.Int,4),
					new SqlParameter("@VPBankAcct", SqlDbType.Int,4),
					new SqlParameter("@VPMasterCard", SqlDbType.Int,4),
					new SqlParameter("@VPMExpirDate", SqlDbType.DateTime),
					new SqlParameter("@VPMCVC2", SqlDbType.Int,4),
					new SqlParameter("@VPSite", SqlDbType.VarChar,32),
					new SqlParameter("@VPNationality", SqlDbType.VarChar,32),
					new SqlParameter("@CreateAt", SqlDbType.DateTime),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,64),
					new SqlParameter("@UpdateDT", SqlDbType.DateTime),
					new SqlParameter("@UpdateBy", SqlDbType.VarChar,64),
					new SqlParameter("@VPID", SqlDbType.Int,4)};
			parameters[0].Value = model.VPFullName;
			parameters[1].Value = model.VPFirstName;
			parameters[2].Value = model.VPMiddleName;
			parameters[3].Value = model.VPLastName;
			parameters[4].Value = model.VPSex;
			parameters[5].Value = model.VPBirthday;
			parameters[6].Value = model.VPMail;
			parameters[7].Value = model.VPNickName;
			parameters[8].Value = model.VPPassword;
			parameters[9].Value = model.VPAge;
			parameters[10].Value = model.VPCollege;
			parameters[11].Value = model.VPOccupation;
			parameters[12].Value = model.VPSsn;
			parameters[13].Value = model.VPHeight;
			parameters[14].Value = model.VPWeight;
			parameters[15].Value = model.VPBloodType;
			parameters[16].Value = model.VPState;
			parameters[17].Value = model.VPCity;
			parameters[18].Value = model.VPStreet;
			parameters[19].Value = model.VPZip;
			parameters[20].Value = model.VPPhone;
			parameters[21].Value = model.VPVisa;
			parameters[22].Value = model.VPVisaExpirDate;
			parameters[23].Value = model.VPCVV2;
			parameters[24].Value = model.VPBank;
			parameters[25].Value = model.VPRoutingNumber;
			parameters[26].Value = model.VPBankAcct;
			parameters[27].Value = model.VPMasterCard;
			parameters[28].Value = model.VPMExpirDate;
			parameters[29].Value = model.VPMCVC2;
			parameters[30].Value = model.VPSite;
			parameters[31].Value = model.VPNationality;
			parameters[32].Value = model.CreateAt;
			parameters[33].Value = model.CreateBy;
			parameters[34].Value = model.UpdateDT;
			parameters[35].Value = model.UpdateBy;
			parameters[36].Value = model.VPID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int VPID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from VirtualPersonInfo ");
			strSql.Append(" where VPID=@VPID");
			SqlParameter[] parameters = {
					new SqlParameter("@VPID", SqlDbType.Int,4)
			};
			parameters[0].Value = VPID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string VPIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from VirtualPersonInfo ");
			strSql.Append(" where VPID in ("+VPIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZHY.Model.VirtualPersonInfo GetModel(int VPID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 VPID,VPFullName,VPFirstName,VPMiddleName,VPLastName,VPSex,VPBirthday,VPMail,VPNickName,VPPassword,VPAge,VPCollege,VPOccupation,VPSsn,VPHeight,VPWeight,VPBloodType,VPState,VPCity,VPStreet,VPZip,VPPhone,VPVisa,VPVisaExpirDate,VPCVV2,VPBank,VPRoutingNumber,VPBankAcct,VPMasterCard,VPMExpirDate,VPMCVC2,VPSite,VPNationality,CreateAt,CreateBy,UpdateDT,UpdateBy from VirtualPersonInfo ");
			strSql.Append(" where VPID=@VPID");
			SqlParameter[] parameters = {
					new SqlParameter("@VPID", SqlDbType.Int,4)
			};
			parameters[0].Value = VPID;

			ZHY.Model.VirtualPersonInfo model=new ZHY.Model.VirtualPersonInfo();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZHY.Model.VirtualPersonInfo DataRowToModel(DataRow row)
		{
			ZHY.Model.VirtualPersonInfo model=new ZHY.Model.VirtualPersonInfo();
			if (row != null)
			{
				if(row["VPID"]!=null && row["VPID"].ToString()!="")
				{
					model.VPID=int.Parse(row["VPID"].ToString());
				}
				if(row["VPFullName"]!=null)
				{
					model.VPFullName=row["VPFullName"].ToString();
				}
				if(row["VPFirstName"]!=null)
				{
					model.VPFirstName=row["VPFirstName"].ToString();
				}
				if(row["VPMiddleName"]!=null)
				{
					model.VPMiddleName=row["VPMiddleName"].ToString();
				}
				if(row["VPLastName"]!=null)
				{
					model.VPLastName=row["VPLastName"].ToString();
				}
				if(row["VPSex"]!=null)
				{
					model.VPSex=row["VPSex"].ToString();
				}
				if(row["VPBirthday"]!=null && row["VPBirthday"].ToString()!="")
				{
					model.VPBirthday=DateTime.Parse(row["VPBirthday"].ToString());
				}
				if(row["VPMail"]!=null)
				{
					model.VPMail=row["VPMail"].ToString();
				}
				if(row["VPNickName"]!=null)
				{
					model.VPNickName=row["VPNickName"].ToString();
				}
				if(row["VPPassword"]!=null)
				{
					model.VPPassword=row["VPPassword"].ToString();
				}
				if(row["VPAge"]!=null && row["VPAge"].ToString()!="")
				{
					model.VPAge=int.Parse(row["VPAge"].ToString());
				}
				if(row["VPCollege"]!=null)
				{
					model.VPCollege=row["VPCollege"].ToString();
				}
				if(row["VPOccupation"]!=null)
				{
					model.VPOccupation=row["VPOccupation"].ToString();
				}
				if(row["VPSsn"]!=null)
				{
					model.VPSsn=row["VPSsn"].ToString();
				}
				if(row["VPHeight"]!=null && row["VPHeight"].ToString()!="")
				{
					model.VPHeight=int.Parse(row["VPHeight"].ToString());
				}
				if(row["VPWeight"]!=null && row["VPWeight"].ToString()!="")
				{
					model.VPWeight=int.Parse(row["VPWeight"].ToString());
				}
				if(row["VPBloodType"]!=null)
				{
					model.VPBloodType=row["VPBloodType"].ToString();
				}
				if(row["VPState"]!=null)
				{
					model.VPState=row["VPState"].ToString();
				}
				if(row["VPCity"]!=null)
				{
					model.VPCity=row["VPCity"].ToString();
				}
				if(row["VPStreet"]!=null)
				{
					model.VPStreet=row["VPStreet"].ToString();
				}
				if(row["VPZip"]!=null && row["VPZip"].ToString()!="")
				{
					model.VPZip=int.Parse(row["VPZip"].ToString());
				}
				if(row["VPPhone"]!=null)
				{
					model.VPPhone=row["VPPhone"].ToString();
				}
				if(row["VPVisa"]!=null && row["VPVisa"].ToString()!="")
				{
					model.VPVisa=int.Parse(row["VPVisa"].ToString());
				}
				if(row["VPVisaExpirDate"]!=null && row["VPVisaExpirDate"].ToString()!="")
				{
					model.VPVisaExpirDate=DateTime.Parse(row["VPVisaExpirDate"].ToString());
				}
				if(row["VPCVV2"]!=null && row["VPCVV2"].ToString()!="")
				{
					model.VPCVV2=int.Parse(row["VPCVV2"].ToString());
				}
				if(row["VPBank"]!=null)
				{
					model.VPBank=row["VPBank"].ToString();
				}
				if(row["VPRoutingNumber"]!=null && row["VPRoutingNumber"].ToString()!="")
				{
					model.VPRoutingNumber=int.Parse(row["VPRoutingNumber"].ToString());
				}
				if(row["VPBankAcct"]!=null && row["VPBankAcct"].ToString()!="")
				{
					model.VPBankAcct=int.Parse(row["VPBankAcct"].ToString());
				}
				if(row["VPMasterCard"]!=null && row["VPMasterCard"].ToString()!="")
				{
					model.VPMasterCard=int.Parse(row["VPMasterCard"].ToString());
				}
				if(row["VPMExpirDate"]!=null && row["VPMExpirDate"].ToString()!="")
				{
					model.VPMExpirDate=DateTime.Parse(row["VPMExpirDate"].ToString());
				}
				if(row["VPMCVC2"]!=null && row["VPMCVC2"].ToString()!="")
				{
					model.VPMCVC2=int.Parse(row["VPMCVC2"].ToString());
				}
				if(row["VPSite"]!=null)
				{
					model.VPSite=row["VPSite"].ToString();
				}
				if(row["VPNationality"]!=null)
				{
					model.VPNationality=row["VPNationality"].ToString();
				}
				if(row["CreateAt"]!=null && row["CreateAt"].ToString()!="")
				{
					model.CreateAt=DateTime.Parse(row["CreateAt"].ToString());
				}
				if(row["CreateBy"]!=null)
				{
					model.CreateBy=row["CreateBy"].ToString();
				}
				if(row["UpdateDT"]!=null && row["UpdateDT"].ToString()!="")
				{
					model.UpdateDT=DateTime.Parse(row["UpdateDT"].ToString());
				}
				if(row["UpdateBy"]!=null)
				{
					model.UpdateBy=row["UpdateBy"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select VPID,VPFullName,VPFirstName,VPMiddleName,VPLastName,VPSex,VPBirthday,VPMail,VPNickName,VPPassword,VPAge,VPCollege,VPOccupation,VPSsn,VPHeight,VPWeight,VPBloodType,VPState,VPCity,VPStreet,VPZip,VPPhone,VPVisa,VPVisaExpirDate,VPCVV2,VPBank,VPRoutingNumber,VPBankAcct,VPMasterCard,VPMExpirDate,VPMCVC2,VPSite,VPNationality,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM VirtualPersonInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" VPID,VPFullName,VPFirstName,VPMiddleName,VPLastName,VPSex,VPBirthday,VPMail,VPNickName,VPPassword,VPAge,VPCollege,VPOccupation,VPSsn,VPHeight,VPWeight,VPBloodType,VPState,VPCity,VPStreet,VPZip,VPPhone,VPVisa,VPVisaExpirDate,VPCVV2,VPBank,VPRoutingNumber,VPBankAcct,VPMasterCard,VPMExpirDate,VPMCVC2,VPSite,VPNationality,CreateAt,CreateBy,UpdateDT,UpdateBy ");
			strSql.Append(" FROM VirtualPersonInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM VirtualPersonInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.VPID desc");
			}
			strSql.Append(")AS Row, T.*  from VirtualPersonInfo T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "VirtualPersonInfo";
			parameters[1].Value = "VPID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

