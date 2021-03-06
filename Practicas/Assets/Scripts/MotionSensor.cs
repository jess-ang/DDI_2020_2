﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using UnityEngine.UI;
public class MotionSensor : MonoBehaviour
{
    public string brokerIpAddress = "192.168.0.113";
	public int brokerPort = 5001;
	public string motionTopic = "casa/patio/movimiento";

    private MqttClient client;
    string lastMessage;
    void Start()
    {
        client = new MqttClient(IPAddress.Parse(brokerIpAddress), brokerPort, false, null);
        
        // register to message received
		client.MqttMsgPublishReceived += client_MqttMsgPublishReceived; //metodo que procesa los mensajes que lleguen al topico (al que estamos suscrito)?

        string clientId = Guid.NewGuid().ToString();
		client.Connect(clientId);

        client.Subscribe(new string[] { motionTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
        // client.Subscribe(new string[] { lightTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
		
    }

    void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
	{
		lastMessage = System.Text.Encoding.UTF8.GetString(e.Message);
	}
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            client.Publish(
                motionTopic,
                System.Text.Encoding.UTF8.GetBytes("Detected"),
                MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
                true
            );
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            client.Publish(
                motionTopic,
                System.Text.Encoding.UTF8.GetBytes("Not detected"),
                MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
                true
            );
        }
    }
    void OnApplicationQuit()
	{
		client.Disconnect();
	}
}