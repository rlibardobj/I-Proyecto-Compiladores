/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:43 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of WriteStatAST.
	/// </summary>
	public class WriteStatAST : StatementAST
	{
		public ExprAST expresion;
		
		public WriteStatAST(ExprAST expr)
		{
			expresion=expr;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitWriteStatAST(this,arg);
		}
	}
}
