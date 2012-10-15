/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:37 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of MulFormParsAST.
	/// </summary>
	public class MulFormParsAST : FormParsAST
	{
		public FormParsAST parametro;
		public FormParsAST parametros;
		  
		public MulFormParsAST(FormParsAST par,FormParsAST pars)
		{
			parametro=par;
			parametros=pars;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitMulFormParsAST(this,arg);
		}
	}
}
