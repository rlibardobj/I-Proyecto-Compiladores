﻿/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 09:52 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of ProgramBasic.
	/// </summary>
	public class ProgramBasic : ProgramAST
	{
		public IDAST ident;
		public ProgramBasic(IDAST id)
		{
			ident=id;
		}
		
		public override object visit(Visitor v,object arg){
				return v.VisitProgramBasicAST(this,arg);
		}
	} 
}
