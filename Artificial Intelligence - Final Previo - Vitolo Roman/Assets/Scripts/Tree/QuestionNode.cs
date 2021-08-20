using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionNode : INode
{
    public delegate bool _qDelegate();
    private _qDelegate _question;
    private INode _trueNode;
    private INode _falseNode;

    public QuestionNode(_qDelegate question, INode tN, INode fN)
    {
        _question = question;
        _trueNode = tN;
        _falseNode = fN;
    }
    
    public void Execute()
    {
        if (_question())
        {
            _trueNode.Execute();
        }
        else
        {
            _falseNode.Execute();
        }
    }
}
