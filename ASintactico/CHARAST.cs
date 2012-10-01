/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 29/09/2012
 * Time: 04:51 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of CHARAST.
	/// </summary>
	public class CHARAST : TerminalesAST
	{
		public string car;
		
		public CHARAST(string c)
		{
			car=c;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitCHARAST(this,arg);
		}
	}
}
