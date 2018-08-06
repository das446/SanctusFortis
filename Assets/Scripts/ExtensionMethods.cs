using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace SanctusFortis {

	public enum Axis { X, Y, Z }

	public static class ExtensionMethods {

		public static void Invoke(this MonoBehaviour control, Action coroutine, float time) {

			control.StartCoroutine(MakeInvokedCoroutine(coroutine, time));
		}

		public static void Invoke(this MonoBehaviour control, Action coroutine, float time, Func<bool> cond) {

			control.StartCoroutine(MakeInvokedCoroutine(coroutine, time, cond));
		}

		public static void InvokeRepeatingWhile(this MonoBehaviour control, Action coroutine, float time, Func<bool> cond) {

			control.StartCoroutine(MakeInvokedCoroutineRepeating(coroutine, time, cond));
		}

		static IEnumerator MakeInvokedCoroutine(Action coroutine, float time) {
			yield return new WaitForSeconds(time);
			coroutine();
		}

		static IEnumerator MakeInvokedCoroutine(Action coroutine, float time, Func<bool> cond) {
			yield return new WaitForSeconds(time);
			if (cond()) {
				coroutine();
			}
		}

		static IEnumerator MakeInvokedCoroutineRepeating(Action coroutine, float time, Func<bool> cond) {
			while (cond()) {
				yield return new WaitForSeconds(time);
				coroutine();

			}
		}

		public static void StopCaller(this MonoBehaviour control) {

			StackFrame frame = new StackFrame(2);
			var method = frame.GetMethod();
			var l = frame.GetFileLineNumber();
			var type = method.DeclaringType;
			var name = method.Name;

			Debug.Log(method + "\n" + type + "\n" + name + "\n" + l);
		}

		public static Vector3 setX(this Vector3 v, float X) {

			return new Vector3(X, v.y, v.z);

		}

		public static Vector3 setY(this Vector3 v, float Y)
    {
        
        return new Vector3(v.x, Y,v.z);
    }

	}

}