/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 23/09/2012
 * Time: 09:29 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of UnExprAST.
	/// </summary>
	public class UnExprAST:ActParsAST
	{
		ExprAST expresion;
		public UnExprAST(ExprAST expr)
		{
			expresion=expr;
		}
	}
}
