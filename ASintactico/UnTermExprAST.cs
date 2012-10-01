/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 23/09/2012
 * Time: 09:32 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of UnTermExprAST.
	/// </summary>
	public class UnTermExprAST:ExprAST
	{
		public TermAST term;
		
		public UnTermExprAST(TermAST ter)
		{
			term = ter;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitUnTermExprAST(this,arg);
		}
	}
}
