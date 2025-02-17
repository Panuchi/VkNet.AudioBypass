﻿using System.Collections.Generic;
using System.Net.Http;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using VkNet.Abstractions.Utils;
using VkNet.Utils;

namespace VkNet.AudioBypassService.Utils
{
	/// <inheritdoc cref="IRestClient" />
	[UsedImplicitly]
	public class RestClientWithUserAgent : RestClient
	{
		private static readonly IDictionary<string, string> VkHeaders = new Dictionary<string, string>
		{
			{ "User-Agent", "VKAndroidApp/7.26-12338 (Android 11; SDK 30; armeabi-v7a; Android; ru; 2960x1440)" },
			{ "x-vk-android-client", "new" }
		};

		public RestClientWithUserAgent(HttpClient httpClient, ILogger<RestClient> logger) : base(httpClient, logger)
		{
			foreach (var header in VkHeaders)
			{
				httpClient.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
			}
		}
	}
}