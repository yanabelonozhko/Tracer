﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

public class TraceResult
{
    public string MethodName;
    public string ClassName;
    public int MethodTime;
}

// Интерфейс, который будет реализовывать класс
public interface ITracer
{
    // Вызвается в начале замеряемого метода 
    void StartTrace();

    // Вызывается в конце замеряемого метода 
    void StopTrace();

    TraceResult GetTraceResult();
}


namespace WinFormsApp1
{

    // Сам класс Tracer
    public class Tracer : ITracer
    {
        delegate void TraceHandler(TraceResult result);
        event TraceHandler MethodFinished;


        Stopwatch stopwatch = new Stopwatch();
        public void StartTrace() {
            stopwatch.Start();
        }
        public void StopTrace() {
            stopwatch.Stop();
            if (MethodFinished != null) MethodFinished(GetTraceResult());
        }

        public TraceResult GetTraceResult()
        {
            TraceResult result = new TraceResult();
            // Тут ещё имя метода и имя класса
            result.MethodTime = Convert.ToInt32(stopwatch.ElapsedTicks);
            return result;
        }
    }
}
