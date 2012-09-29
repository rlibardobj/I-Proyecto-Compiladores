﻿/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:42 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of IfStatAST.
	/// </summary>
	public class IfStatAST : StatementAST
	{
		StatementAST statement;
		ConditionsAST condicion;
		public IfStatAST(ConditionsAST cond, StatementAST sta)
		{
			statement=sta;
			condicion=cond;
		}
	}
}