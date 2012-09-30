/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 23/09/2012
 * Time: 09:18 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of MulCondTerm.
	/// </summary>
	public class MulCondTermAST:ConditionsAST
	{
		ConditionsAST condterm;
		ConditionsAST condterms;
		public MulCondTermAST(ConditionsAST cond, ConditionsAST conds)
		{
			condterm=cond;
			condterms=conds;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitMulCondTermAST(this,arg);
		}
	}
}
