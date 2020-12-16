using UnityEngine;
using System.Collections;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using UnityEngine.UI;
using System;

public class DashboardClient : MonoBehaviour
{
	public string brokerIpAddress = "192.168.0.113"; //aqui se pone el endpoint aws, mosquito, etc
	public int brokerPort = 5001;
	public string temperatureTopic = "casa/sala/temperatura";
	public string motionTopic = "casa/patio/movimiento";
	public string lightTopic = "casa/patio/luz";
	private MqttClient client;
	public Text temperatureText;
    public Text motionText;
    public Text lightsText;
	public GameObject directionalLight;
	public GameObject[] firePlace;
	string lastMessage;
	string motionMsg;
    string lightsMsg;
	string temperature = "0";
	volatile bool lights = false;
	volatile bool fire = false;
	
	// Use this for initialization
	void Start () {
		// create client instance
		client = new MqttClient(IPAddress.Parse(brokerIpAddress), brokerPort, false, null);

		// register to message received
		client.MqttMsgPublishReceived += client_MqttMsgPublishReceived; //metodo que procesa los mensajes que lleguen al topico (al que estamos suscrito)?

		string clientId = Guid.NewGuid().ToString();
		client.Connect(clientId);

		// subscribe to the topic "/home/temperature" with QoS 2
		client.Subscribe(new string[] { temperatureTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
		client.Subscribe(new string[] { lightTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
        client.Subscribe(new string[] { motionTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

	}
	void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
	{
		Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(e.Message));
		lastMessage = System.Text.Encoding.UTF8.GetString(e.Message);
		if(e.Topic.Equals(motionTopic))
		{
            if(lastMessage.Equals("Detected"))
			{
                lightsMsg = "On";
			}
			else if(lastMessage.Equals("Not detected"))
			{
				lightsMsg = "Off";
			}
            client.Publish(
                lightTopic,
                System.Text.Encoding.UTF8.GetBytes(lightsMsg),
                MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
                true
            );
			motionMsg = lastMessage;
		}
		if(e.Topic.Equals(lightTopic))
        {
            if(lastMessage.Equals("On"))
			{
				lights = true;
			}
			else if(lastMessage.Equals("Off"))
			{
				lights = false;
			}
            lightsMsg = lastMessage;
        }
		if (e.Topic.Equals(temperatureTopic))
		{
			if(Int32.Parse(lastMessage) < 16)
			{
				fire = true;
			}
			else
			{
				fire = false;
			}
			temperature = lastMessage;
		}
	}

	void Update()
	{
		temperatureText.text = temperature + " C";
		motionText.text = motionMsg;
        lightsText.text = lightsMsg;
        if (lights != directionalLight.activeSelf)
			directionalLight.SetActive(lights);
        if (fire != firePlace[0].activeSelf)
		{
			foreach (GameObject i in firePlace)
			{
				i.SetActive(fire);
			}
		}
	}

	// void OnGUI(){
	// 	if ( GUI.Button (new Rect (20,40,80,20), "ENVIAR TEST")) {
	// 		Debug.Log("sending...");
	// 		client.Publish("casa/sala/luz", System.Text.Encoding.UTF8.GetBytes("lightOn"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
	// 		Debug.Log("sent");
	// 	}
	// }

	void OnApplicationQuit()
	{
		client.Disconnect();
	}
}