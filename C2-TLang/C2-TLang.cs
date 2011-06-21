using System;

namespace C2_TLang
{
    class Program
    {
        static void Main()
        {
#if DEBUG
            string[] input = {
                                 "^= ^# ^# 164 268$ ^@ 256$$ 287$",
                                 "^@ ^# 59 ^# 205 235$$$",
                                 "^= 272 ^# 275 3$$",
                                 "^# ^= 10 ^# 260 199$$ 35$",
                                 "^= ^@ 224 37$ ^@ 260 194$$"
                             };
            foreach (var line in input)
            {
                float f = Resolve(line);
                Console.WriteLine((Int32)f);
            }
#endif
#if !DEBUG
            var stream = Console.In;
            string line;
            while ((line = stream.ReadLine()) != null)
            {
                float f = Resolve(line);
                Console.WriteLine((Int32)f);
                // Check EOF));
                if (stream.Peek() == -1) break;
            }
#endif
        }

        /// <summary>
        /// Parse and resolve the line
        /// </summary>
        static float Resolve(string line)
        {
            char operation;
            string op1, op2;
            
            Chop(line, out operation, out op1, out op2);

            var op1F = op1[0] == '^' ? Resolve(op1) : Int32.Parse(op1);
            var op2F = op2[0] == '^' ? Resolve(op2) : Int32.Parse(op2);

            switch (operation)
            {
                case '=':
                    return op1F + op2F;
                case '#':
                    return op1F * op2F;
                case '@':
                    return op1F - op2F;                        
            }
            throw new ArgumentException("Line is wrong");
        }

        /// <summary>
        /// Analyze the line and returns the operation and the operands
        /// </summary>
        static void Chop(string line, out char operation, out string op1, out string op2)
        {
            operation = line[1];

            // Let's go with the first operand
            var index = 3;
            if (line[index] == '^')
            {
                var depth = 1;
                for (var i = index + 1; ; i++)
                {
                    if (line[i] == '^') depth++;
                    if (line[i] == '$') depth--;
                    if (depth == 0)
                    {
                        op1 = line.Substring(index, i - index + 1);
                        index = i + 1;
                        break;
                    }
                }
            }
            else
            {
                for (int i = index + 1; ; i++)
                {
                    if (line[i] == ' ' || i + 2 > line.Length)
                    {
                        op1 = line.Substring(index, i - index);
                        index = i;
                        break;
                    }
                }
            }            
            index++;
            // If we are done there is only one operand and it is a substract operation so 
            // make a little trick
            if (!(index < line.Length)) {
                op2 = op1;
                op1 = "0";
                return;
            }
            // Let's go with second operand
            if (line[index] == '^')
            {
                int depth = 1;
                for (int i = index + 1; ; i++)
                {
                    if (line[i] == '^') depth++;
                    if (line[i] == '$') depth--;
                    if (depth == 0)
                    {
                        op2 = line.Substring(index, i - index + 1);
                        break;
                    }
                }
            }
            else
            {
                for (int i = index; ; i++)
                {
                    if (!(i + 1 < line.Length) || line[i] == ' ' || line[i] == '$')
                    {
                        op2 = line.Substring(index, i - index);
                        break;
                    }
                }
            } 
        }
    }
}
