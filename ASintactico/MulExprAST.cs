/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 23/09/2012
 * Time: 09:30 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of MulExprAST.
	/// </summary>
	public class MulExprAST:ActParsAST
	{
		public ActParsAST expresion;
		public ActParsAST expresiones;
		
		public MulExprAST(ActParsAST expr, ActParsAST exprs)
		{
			expresion=expr;
			expresiones=exprs;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitMulExprAST(this,arg);
		}
	}
}
