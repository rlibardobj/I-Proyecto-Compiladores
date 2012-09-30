/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 23/09/2012
 * Time: 09:43 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of NumFactorAST.
	/// </summary>
	public class NumFactorAST:FactorAST
	{
		NUMAST num;
		public NumFactorAST(NUMAST n)
		{
			num=n;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitNumFactorAST(this,arg);
		}
	}
}
