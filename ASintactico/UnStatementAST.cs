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
	/// Description of UnStatementAST.
	/// </summary>
	public class UnStatementAST : StatementsAST
	{
		public StatementAST statement;
		
		public UnStatementAST(StatementAST sta)
		{
			statement=sta;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitUnStatementAST(this,arg);
		}
	}
}
