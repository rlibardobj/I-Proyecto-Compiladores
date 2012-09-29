/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 23/09/2012
 * Time: 09:42 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of DesigPFactorAST.
	/// </summary>
	public class DesigPFactorAST:FactorAST
	{
		DesignatorAST desig;
		public DesigPFactorAST(DesignatorAST des)
		{
			desig=des;
		}
	}
}
