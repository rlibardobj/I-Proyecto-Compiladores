/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:46 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of ForBasicStatAST.
	/// </summary>
	public class ForBasicStatAST : StatementAST
	{
		ExprAST expresion;
		StatementAST statement;
		public ForBasicStatAST(ExprAST expr, StatementAST sta)
		{
			expresion=expr;
			statement=sta;
		}
	}
}
