﻿/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:44 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of WriteNStatAST.
	/// </summary>
	public class WriteNStatAST : StatementAST
	{
		ExprAST expresion;
		public WriteNStatAST(ExprAST expr)
		{
			expresion=expr;
		}
	}
}
