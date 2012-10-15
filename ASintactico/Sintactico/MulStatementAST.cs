/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:41 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of MulStatementAST.
	/// </summary>
	public class MulStatementAST : StatementsAST
	{
		public StatementsAST statement;
		public StatementsAST statements;
		
		public MulStatementAST(StatementsAST sta, StatementsAST stas)
		{
			statement=sta;
			statements=stas;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitMulStatementAST(this,arg);
		}
	}
}
