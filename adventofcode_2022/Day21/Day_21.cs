using System.Collections.Immutable;

namespace AdventOfCode_2022.Day21;
public class Day_21 : IDay
{
    private const string HumanID = "humn";
    public static int Step = 0;
    private readonly string base_path;
    public Day_21()
    {
        base_path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)!;
    }

    public string Day => "Day 21";

    public string FirstFilePath => base_path + "/Day21/input_1.txt";

    public string SecondFilePath => base_path + "/Day21/input_1.txt";

    public string GetFirstOutput(string[] data)
    {
        var result = ParseLine(data);
        var root = result.First(p => p.ID == "root");

        return root.GetValue(result).ToString();
    }

    public string GetSecondOutput(string[] data)
    {
        var result = ParseLine(data);
        ComplexMonkey root = (ComplexMonkey)result.First(p => p.ID == "root");

        var goal = 0L;

        var left = result.First(p => p.ID == root.Left);
        var right = result.First(p => p.ID == root.Right);

        if (left is ComplexMonkey lComplex && ContainsHuman(result, lComplex))
        {
            goal = right.GetValue(result);
            goal = Calculate(result, goal, lComplex);
        }
        else if (right is ComplexMonkey rComplex && ContainsHuman(result, rComplex))
        {
            goal = right.GetValue(result);
            goal = Calculate(result, goal, rComplex);
        }

        return goal.ToString();
    }

    private long Calculate(IList<INumberOrMonkey> monkeys, long goal, INumberOrMonkey current)
    {
        // The result of this monkey should be equal to goal
        // We can only change the monkey {HumanID} value
        // So keep iterating until we can find it and change it's value
        // Then return what the value we changed it to

        // goal = left + h
        // goal - left = h
        // 
        // goal = left - h;
        // goal + h = left;
        // h = left - goal;
        //
        // goal = left * h
        // goal / left = h
        // 6 = 3 * 2
        // 6 / 3 = 2
        //
        // goal = left / h
        // goal * h = left
        // h = left / goal
        // 6 = 12 / 2
        // 6 * 2 = 12
        // 2 = 12 / 6
        //
        // 1 = 3 - 2;
        // 1 + 2 = 3;
        // 2 = 3-1;

        if (current is NumberMonkey && current.ID == HumanID)
        {
            Console.WriteLine("Got him");
            return goal;
        }
        
        ComplexMonkey cComplex = (ComplexMonkey)current;


        var left = monkeys.First(p => p.ID == cComplex.Left);
        var right = monkeys.First(p => p.ID == cComplex.Right);
        var operation = cComplex.Operation;


        if ((left is ComplexMonkey lComplex && ContainsHuman(monkeys, lComplex)) || left.ID == HumanID)
        {
            var rightResult = right.GetValue(monkeys);

            var newGoal = 0L;

            if (operation == OpType.Add) newGoal = goal - rightResult;
            else if (operation == OpType.Sub) newGoal = goal + rightResult;
            else if (operation == OpType.Div) newGoal = goal * rightResult;
            else if (operation == OpType.Mul) newGoal = goal / rightResult;

            if (left.ID == HumanID)
            {
                // Found human
                return newGoal;
            } else
            {
                lComplex = (ComplexMonkey)left;
                return Calculate(monkeys, newGoal, lComplex);
            }
        }
        else if ((right is ComplexMonkey rComplex && ContainsHuman(monkeys, rComplex)) || right.ID == HumanID)
        {
            var leftResult = left.GetValue(monkeys);

            var newGoal = 0L;

            if (operation == OpType.Add) newGoal = goal - leftResult;
            else if (operation == OpType.Sub) newGoal = leftResult - goal;
            else if (operation == OpType.Div) newGoal = leftResult / goal;
            else if (operation == OpType.Mul) newGoal = goal / leftResult;


            if (right.ID == HumanID)
            {
                // Found human
                return newGoal;
            } else
            {
                rComplex = (ComplexMonkey)right;
                return Calculate(monkeys, newGoal, rComplex);
            }
        }


        throw new InvalidOperationException();
    }

    private bool ContainsHuman(IList<INumberOrMonkey> monkeys, ComplexMonkey monkey)
    {
        var left = monkeys.First(p => p.ID == monkey.Left);
        var right = monkeys.First(p => p.ID == monkey.Right);

        if (left is ComplexMonkey)
        {
            if (ContainsHuman(monkeys, (ComplexMonkey)left)) return true;
        }
        else if (left.ID == HumanID)
        {
            return true;
        }

        if (right is ComplexMonkey)
        {
            if (ContainsHuman(monkeys, (ComplexMonkey)right)) return true;
        }
        else if (right.ID == HumanID)
        {
            return true;
        }

        return false;

    }

    private IList<INumberOrMonkey> ParseLine(string[] data)
    {
        var list = new List<INumberOrMonkey>();

        for (int i = 0; i < data.Length; i++)
        {
            INumberOrMonkey monkey = ParseMonkey(list, data[i]);
            list.Add(monkey);
        }
        return list;
    }

    private INumberOrMonkey ParseMonkey(List<INumberOrMonkey> list, string v)
    {
        var details = v.Split(':');

        if (Char.IsDigit(details[1].Trim()[0]))
        {
            int num = Int32.Parse(details[1]);
            INumberOrMonkey number = new NumberMonkey(details[0], num);
            return number;
        }
        else
        {
            var sub = details[1].Trim().Split(" ");
            INumberOrMonkey monkey = new ComplexMonkey(details[0], sub[0], sub[2], sub[1]);
            return monkey;
        }
    }
    interface INumberOrMonkey
    {
        string ID { get; set; }
        long GetValue(IList<INumberOrMonkey> monkeys);
    }

    class NumberMonkey : INumberOrMonkey
    {
        private long value;
        public string ID { get; set; }
        public NumberMonkey(string id, long val)
        {
            ID = id;
            value = val;
        }

        public long GetValue(IList<INumberOrMonkey> monkeys) => value;
    }

    class ComplexMonkey : INumberOrMonkey
    {
        public string Left;
        public string Right;
        public OpType Operation;

        public string ID { get; set; }

        private long val = -1;

        public ComplexMonkey(string id, string left, string right, string operation)
        {
            ID = id;
            this.Left = left;
            this.Right = right;

            switch (operation)
            {
                case "*":
                    Operation = OpType.Mul;
                    break;
                case "/":
                    Operation = OpType.Div;
                    break;
                case "-":
                    Operation = OpType.Sub;
                    break;
                case "+":
                    Operation = OpType.Add;
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }

        public long GetValue(IList<INumberOrMonkey> monkeys)
        {
            if (this.val != -1) return val;

            Day_21.Step++;

            var newVal = getVal(monkeys);
            val = newVal;


            Console.WriteLine(" ".PadLeft(Step) + monkeys.First(p => p.ID == Left).GetValue(monkeys) + "," + Operation + "," + monkeys.First(p => p.ID == Right).GetValue(monkeys) + ", " + val);
            Day_21.Step--;

            return val;
        }

        private Int64 getVal(IList<INumberOrMonkey> monkeys)
            => Operation switch
            {
                OpType.Add => (monkeys.First(p => p.ID == Left).GetValue(monkeys) + monkeys.First(p => p.ID == Right).GetValue(monkeys)),
                OpType.Sub => (monkeys.First(p => p.ID == Left).GetValue(monkeys) - monkeys.First(p => p.ID == Right).GetValue(monkeys)),
                OpType.Div => (monkeys.First(p => p.ID == Left).GetValue(monkeys) / monkeys.First(p => p.ID == Right).GetValue(monkeys)),
                OpType.Mul => (monkeys.First(p => p.ID == Left).GetValue(monkeys) * monkeys.First(p => p.ID == Right).GetValue(monkeys)),
                _ => throw new InvalidOperationException("Undefined operation")
            };

        public override string ToString()
        {
            return $"{Left} {Operation} {Right} : {val}";
        }
    }

    enum OpType
    {
        Add,
        Sub,
        Div,
        Mul
    }
}