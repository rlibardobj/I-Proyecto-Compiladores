/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:36 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of UnFormParsAST.
	/// </summary>
	public class UnFormParsAST : FormParsAST
	{
		TypeAST tipo;
		TerminalesAST ident;
		public UnFormParsAST(TerminalesAST id,TypeAST tip)
		{
			tipo=tip;
			ident=id;
		}
	}
}
