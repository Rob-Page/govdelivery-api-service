﻿using GovDelivery.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GovDelivery.Models.Rest.Subscriber
{
    [XmlRoot]
    public class CreateSubscriberModel
    {
        [XmlElement(ElementName = "email")]
        public string Email { get; set; }

        [XmlElement(ElementName = "country-code")]
        public string CountryCode { get; set; }

        [XmlElement(ElementName = "phone")]
        public string Phone { get; set; }

        [XmlElement(ElementName = "send-notifications")]
        public bool SendSubscriberUpdateNotifications { get; set; }

        [XmlElement(DataType = "integer", ElementName = "digest-for")]
        public BulletinFrequency BulletinFrequency { get; set; }

    }

    [XmlRoot(ElementName = "subscriber")]
    public class CreateSubscriberResponseModel
    {
        [XmlElement(ElementName = "to-param")]
        public int SubscriberId { get; set; }

        [XmlElement(ElementName = "link")]
        public string SubscriberInfoLink { get; set; }
    }
}
