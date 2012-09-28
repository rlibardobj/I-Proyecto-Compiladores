/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:33 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of MethodDeclFAST.
	/// </summary>
	public class MethodDeclFAST : MethodDeclAST
	{
		FormParsAST parametros;
		public MethodDeclFAST(FormParsAST par)
		{
			parametros=par;
		}
	}
}
