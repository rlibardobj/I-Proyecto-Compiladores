﻿/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:39 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of BlockBasicAST.
	/// </summary>
	public class BlockBasicAST : BlockAST
	{
		public BlockBasicAST()
		{
		}
		
	public override object visit(Visitor v,object arg){
		return v.VisitBlockBasicAST(this,arg);
		}
	}
}
