/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 29/09/2012
 * Time: 04:52 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of NUMAST.
	/// </summary>
	public class NUMAST : TerminalesAST
	{
		public string num;
		
		public NUMAST(string n)
		{
			num=n;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitNUMAST(this,arg);
		}
	}
}
