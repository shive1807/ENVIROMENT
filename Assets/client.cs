using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Net.Sockets;

public class client :
MonoBehaviour
{
	bool socketReady = false;
	float x = 0;
	float y = 0;
	float z = 0;
	float k=5;
	String x1 = "";
	String y1 = "";
	String z1 = "";
	int[,] array = new int[5,3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

	TcpClient mySocket;
	NetworkStream theStream;
	StreamWriter theWriter;
	StreamReader theReader;
	String Host = "192.168.43.123";
	Int32 Port = 8080;

	private bool dirRight = true;
	//public float speed = 2.0f;

	// Use this for initialization
	void Start()
	{
		setupSocket();
	}

	// Update is called once per frame
	void Update()
	{
		String a=readSocket();
		if (!a.Equals(""))
		{
			x1 = "";
			y1 = "";
			z1 = "";
			int o = 0;
			for (int i = 0; i < a.Length; i++)
			{
				if (o == 0) {
					if (a [i] == ' ') {
						o = 2;
						continue;
					}
					x1 = x1 + a [i];

				}
				if (o == 2)
				{
					z1 = z1 + a[i];

				}
			}
			print(a);
			x=float.Parse(x1);
			//Int32.TryParse(y1, out y);
			z=float.Parse(z1);
			transform.position = new Vector3(k*x, 0, k*z);
			maintainConnection();
		}
		/*  if (dirRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * speed * Time.deltaTime);

        if (transform.position.x >= 4.0f)
        {
            dirRight = false;
        }

        if (transform.position.x <= -4)
        {
            dirRight = true;
        }*/
	}

	public void setupSocket()
	{
		try
		{
			mySocket = new TcpClient(Host, Port);
			theStream = mySocket.GetStream();
			theWriter = new StreamWriter(theStream);
			theReader = new StreamReader(theStream);
			socketReady = true;
			print("oyu");
		}
		catch (Exception e)
		{
			Debug.Log("Socket error:" + e);
		}
	}

	public void writeSocket(string theLine)
	{
		if (!socketReady)
			return;
		String tmpString = theLine + "\r\n";
		theWriter.Write(tmpString);
		theWriter.Flush();
	}

	public String readSocket()
	{
		print("dekha");
		if (!socketReady)
			return "";
		//print("FO");
		if (theStream.DataAvailable)
		{
			print("LEo");
			return theReader.ReadLine();
		}
		return "";
	}

	public void closeSocket()
	{
		if (!socketReady)
			return;
		theWriter.Close();
		theReader.Close();
		mySocket.Close();
		socketReady = false;
	}

	public void maintainConnection()
	{
		if (!theStream.CanRead)
		{
			setupSocket();
		}
	}

} // end class s_TCP