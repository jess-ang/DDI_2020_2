using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using UnityEngine.UI;
public class LightsController : MonoBehaviour
{
    public string brokerIpAddress = "192.168.0.113";
	public int brokerPort = 5001;
	public string lightTopic = "casa/patio/luz";
    private MqttClient client;
    string lastMessage;
    string lightsAction;
    public GameObject directionalLight;
    // public Button yourButton;

    void Start()
    {
        Button btn = GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
        client = new MqttClient(IPAddress.Parse(brokerIpAddress), brokerPort, false, null);
        
        // register to message received
		client.MqttMsgPublishReceived += client_MqttMsgPublishReceived; //metodo que procesa los mensajes que lleguen al topico (al que estamos suscrito)?

        string clientId = Guid.NewGuid().ToString();
		client.Connect(clientId);

        client.Subscribe(new string[] { lightTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
		
    }

    void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
	{
		lastMessage = System.Text.Encoding.UTF8.GetString(e.Message);
        if(e.Topic.Equals(lightTopic))
        {
            if(lastMessage.Equals("On"))
            {
                lightsAction = "Off";
            }
            else if(lastMessage.Equals("Off"))
            {
                lightsAction = "On";
            }
        }
	}

    public void TaskOnClick()
    {
        client.Publish(
            lightTopic,
            System.Text.Encoding.UTF8.GetBytes(lightsAction),
            MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
            true
        );
	}
    
    void OnApplicationQuit()
	{
		client.Disconnect();
	}
}