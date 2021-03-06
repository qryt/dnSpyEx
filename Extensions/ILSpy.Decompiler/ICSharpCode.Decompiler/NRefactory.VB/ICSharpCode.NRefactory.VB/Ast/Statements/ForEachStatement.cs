// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under MIT X11 license (for details please see \doc\license.txt)

using System;
using System.Collections.Generic;
using dnSpy.Contracts.Decompiler;

namespace ICSharpCode.NRefactory.VB.Ast {
	public class ForEachStatement : Statement
	{
		public static readonly Role<AstNode> VariableRole = new Role<AstNode>("Variable", AstNode.Null);
		
		public AstNode Variable {
			get { return GetChildByRole(VariableRole); }
			set { SetChildByRole(VariableRole, value); }
		}
		
		public Expression InExpression {
			get { return GetChildByRole(Roles.Expression); }
			set { SetChildByRole(Roles.Expression, value); }
		}
		
		public BlockStatement Body {
			get { return GetChildByRole(Roles.Body); }
			set { SetChildByRole(Roles.Body, value); }
		}
		
		public IList<ILSpan> HiddenInitializer { get; set; }			// |foreach| (var c in args)
		public IList<ILSpan> HiddenGetEnumeratorILSpans { get; set; }	// foreach (var c in |args|)
		public IList<ILSpan> HiddenMoveNextILSpans { get; set; }		// foreach (var c |in| args)
		public IList<ILSpan> HiddenGetCurrentILSpans { get; set; }		// foreach (|var c| in args)

		protected internal override bool DoMatch(AstNode other, ICSharpCode.NRefactory.PatternMatching.Match match)
		{
			throw new NotImplementedException();
		}
		
		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitForEachStatement(this, data);
		}
	}
}
