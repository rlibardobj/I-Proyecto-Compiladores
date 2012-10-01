/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 29/09/2012
 * Time: 06:54 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of ConditionAST.
	/// </summary>
	public class ConditionAST:CondFactAST
	{
		public ExprAST expr,expr1;
		public RELOPAST relop;
		
		public ConditionAST(ExprAST exp, ExprAST exp1, RELOPAST rel)
		{
			relop=rel;
			expr=exp;
			expr1=exp1;
		}
		public override object visit(Visitor v,object arg){
			return v.VisitConditionAST(this,arg);
		}
	}
}
