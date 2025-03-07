﻿using CLLM.Core;
using System.IO;

namespace RWKV
{
    public static class RunnerFactoryExtend
    {
        public static void RegisterRWKVOnnxModel(this RunnerFactory runnerFactory, string modelPath, string tokenizerPath, int embed, int layers)
        {
            runnerFactory.RegisterRWKVOnnxModel("Default", modelPath, tokenizerPath, embed, layers);
        }

        public static void RegisterRWKVOnnxModel(this RunnerFactory runnerFactory, string name, string modelPath, string tokenizerPath, int embed, int layers)
        {
            runnerFactory.RegisterRunner<Runner>(
                name,
                new OnnxModel(modelPath, embed, layers),
                new RunnerOptions()
                {
                    Tokenizer = new Tokenizer(tokenizerPath)
                }
            );
        }
    }
}
