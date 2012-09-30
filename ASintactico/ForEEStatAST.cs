/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:48 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of ForEEStatAST.
	/// </summary>
	public class ForEEStatAST : StatementAST
	{
		ExprAST expresion,expresion1,expresion2;
		StatementAST statement;
		public ForEEStatAST(ExprAST expr, ExprAST expr1, ExprAST expr2, StatementAST sta)
		{
			expresion=expr;
			expresion1=expr1;
			expresion2=expr2;
			statement=sta;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitForEEStatAST(this,arg);
		}
	}
}
