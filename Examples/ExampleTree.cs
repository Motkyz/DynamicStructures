namespace list;
using System;
using System.Collections.Generic;

public class ExampleTree
{

    class DecisionNode
    {
        public string Question { get; set; }
        public DecisionNode TrueBranch { get; set; }
        public DecisionNode FalseBranch { get; set; }

        public DecisionNode(string question)
        {
            Question = question;
            TrueBranch = null;
            FalseBranch = null;
        }
    }

    class DecisionTree
    {
        private DecisionNode root;

        public DecisionTree()
        {
            root = BuildDecisionTree();
        }

        private DecisionNode BuildDecisionTree()
        {
            // Создаем дерево решений
            DecisionNode root = new DecisionNode("Is it raining?");
            root.TrueBranch = new DecisionNode("Take an umbrella.");
            root.FalseBranch = new DecisionNode("No need for an umbrella.");
            return root;
        }

        public void AskQuestion(DecisionNode node)
        {
            if (node == null)
            {
                return;
            }

            if (node.TrueBranch == null && node.FalseBranch == null)
            {
                Console.WriteLine(node.Question);
                return;
            }

            Console.Write(node.Question + " (yes/no): ");
            string answer = Console.ReadLine();

            if (answer?.ToLower() == "yes")
            {
                AskQuestion(node.TrueBranch);
            }
            else
            {
                AskQuestion(node.FalseBranch);
            }
        }

        public void Start()
        {
            AskQuestion(root);
        }
    }
}
