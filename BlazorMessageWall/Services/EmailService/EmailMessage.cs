﻿namespace BlazorMessageWall.Services.EmailService
{
	public class EmailMessage
	{
		public string ToEmail { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
	}
}
