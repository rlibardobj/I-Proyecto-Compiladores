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
	/// Description of UnCondTerm.
	/// </summary>
	public class UnCondTermAST:ConditionsAST
	{
		public CondTermAST condterm;
		
		public UnCondTermAST(CondTermAST cond)
		{
			condterm=cond;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitUnCondTermAST(this,arg);
		}
	}
}
