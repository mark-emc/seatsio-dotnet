﻿using System;
using RestSharp;
using SeatsioDotNet.Util;

namespace SeatsioDotNet.Test
{
    public class SeatsioClientTest
    {
        private static readonly string BaseUrl = "https://api-staging.seats.io";

        protected readonly TestUser User;
        protected readonly SeatsioClient Client;

        protected SeatsioClientTest()
        {
            User = CreateTestUser();
            Client = CreateSeatsioClient(User.SecretKey);
        }

        private TestUser CreateTestUser()
        {
            var restClient = new RestClient(BaseUrl);
            var email = "test" + new Random().Next() + "@seats.io";
            var password = "12345678";
            var request = new RestRequest("/system/public/users", Method.POST)
                .AddJsonBody(new {email, password});
            return RestUtil.AssertOk(restClient.Execute<TestUser>(request));
        }

        protected string CreateTestChart()
        {
            var restClient = new RestClient(BaseUrl);
            var chartKey = Guid.NewGuid().ToString();
            var testChartJson = TestChartJson();
            var request = new RestRequest("/system/public/{designerKey}/charts/{chartKey}", Method.POST)
                .AddUrlSegment("designerKey", User.DesignerKey)
                .AddUrlSegment("chartKey", chartKey)
                .AddParameter("application/json", testChartJson, ParameterType.RequestBody);
            RestUtil.AssertOk(restClient.Execute<object>(request));
            return chartKey;
        }

        protected SeatsioClient CreateSeatsioClient(string secretKey)
        {
            return new SeatsioClient(secretKey, BaseUrl);
        }

        private string TestChartJson()
        {
            return "{\"name\":\"Sample chart\",\"tablesLabelCounter\":3,\"uuidCounter\":369,\"categories\":{\"list\":[{\"label\":\"Cat1\",\"color\":\"#87A9CD\",\"accessible\":false,\"key\":9},{\"label\":\"Cat2\",\"color\":\"#5E42ED\",\"accessible\":false,\"key\":10}],\"maxCategoryKey\":10},\"version\":17,\"venueType\":\"ROWS_WITHOUT_SECTIONS\",\"showAllButtons\":false,\"sectionScaleFactor\":100,\"subChart\":{\"height\":95,\"width\":442,\"tables\":[],\"texts\":[],\"rows\":[{\"label\":\"A\",\"seatLabeling\":{\"algoName\":\"SimpleNumbers\",\"startAtIndex\":0,\"isInverted\":false},\"objectLabeling\":{\"algoName\":\"SimpleLettersUppercase\",\"prefix\":\"\",\"startAtIndex\":0},\"seats\":[{\"x\":151.94,\"y\":9,\"label\":\"1\",\"categoryLabel\":\"Cat1\",\"categoryAccessible\":false,\"categoryKey\":9,\"uuid\":\"uuid288\"},{\"x\":171.94,\"y\":9,\"label\":\"2\",\"categoryLabel\":\"Cat1\",\"categoryAccessible\":false,\"categoryKey\":9,\"uuid\":\"uuid289\"},{\"x\":191.94,\"y\":9,\"label\":\"3\",\"categoryLabel\":\"Cat1\",\"categoryAccessible\":false,\"categoryKey\":9,\"uuid\":\"uuid290\"},{\"x\":211.94,\"y\":9,\"label\":\"4\",\"categoryLabel\":\"Cat1\",\"categoryAccessible\":false,\"categoryKey\":9,\"uuid\":\"uuid291\"},{\"x\":231.94,\"y\":9,\"label\":\"5\",\"categoryLabel\":\"Cat1\",\"categoryAccessible\":false,\"categoryKey\":9,\"uuid\":\"uuid292\"},{\"x\":251.94,\"y\":9,\"label\":\"6\",\"categoryLabel\":\"Cat1\",\"categoryAccessible\":false,\"categoryKey\":9,\"uuid\":\"uuid293\"},{\"x\":271.94,\"y\":9,\"label\":\"7\",\"categoryLabel\":\"Cat1\",\"categoryAccessible\":false,\"categoryKey\":9,\"uuid\":\"uuid294\"},{\"x\":291.94,\"y\":9,\"label\":\"8\",\"categoryLabel\":\"Cat1\",\"categoryAccessible\":false,\"categoryKey\":9,\"uuid\":\"uuid295\"}],\"curve\":0,\"chairSpacing\":4,\"objectType\":\"row\",\"uuid\":\"uuid297\"},{\"label\":\"B\",\"seatLabeling\":{\"algoName\":\"SimpleNumbers\",\"startAtIndex\":0,\"isInverted\":false},\"objectLabeling\":{\"algoName\":\"SimpleLettersUppercase\",\"prefix\":\"\",\"startAtIndex\":0},\"seats\":[{\"x\":151.94,\"y\":33,\"label\":\"1\",\"categoryLabel\":\"Cat1\",\"categoryAccessible\":false,\"categoryKey\":9,\"uuid\":\"uuid298\"},{\"x\":171.94,\"y\":33,\"label\":\"2\",\"categoryLabel\":\"Cat1\",\"categoryAccessible\":false,\"categoryKey\":9,\"uuid\":\"uuid299\"},{\"x\":191.94,\"y\":33,\"label\":\"3\",\"categoryLabel\":\"Cat1\",\"categoryAccessible\":false,\"categoryKey\":9,\"uuid\":\"uuid300\"},{\"x\":211.94,\"y\":33,\"label\":\"4\",\"categoryLabel\":\"Cat1\",\"categoryAccessible\":false,\"categoryKey\":9,\"uuid\":\"uuid301\"},{\"x\":231.94,\"y\":33,\"label\":\"5\",\"categoryLabel\":\"Cat1\",\"categoryAccessible\":false,\"categoryKey\":9,\"uuid\":\"uuid302\"},{\"x\":251.94,\"y\":33,\"label\":\"6\",\"categoryLabel\":\"Cat1\",\"categoryAccessible\":false,\"categoryKey\":9,\"uuid\":\"uuid303\"},{\"x\":271.94,\"y\":33,\"label\":\"7\",\"categoryLabel\":\"Cat1\",\"categoryAccessible\":false,\"categoryKey\":9,\"uuid\":\"uuid304\"},{\"x\":291.94,\"y\":33,\"label\":\"8\",\"categoryLabel\":\"Cat1\",\"categoryAccessible\":false,\"categoryKey\":9,\"uuid\":\"uuid305\"}],\"curve\":0,\"chairSpacing\":4,\"objectType\":\"row\",\"uuid\":\"uuid307\"},{\"label\":\"C\",\"seatLabeling\":{\"algoName\":\"SimpleNumbers\",\"startAtIndex\":0,\"isInverted\":false},\"objectLabeling\":{\"algoName\":\"SimpleLettersUppercase\",\"prefix\":\"\",\"startAtIndex\":0},\"seats\":[{\"x\":151.94,\"y\":57,\"label\":\"1\",\"categoryLabel\":\"Cat2\",\"categoryAccessible\":false,\"categoryKey\":10,\"uuid\":\"uuid308\"},{\"x\":171.94,\"y\":57,\"label\":\"2\",\"categoryLabel\":\"Cat2\",\"categoryAccessible\":false,\"categoryKey\":10,\"uuid\":\"uuid309\"},{\"x\":191.94,\"y\":57,\"label\":\"3\",\"categoryLabel\":\"Cat2\",\"categoryAccessible\":false,\"categoryKey\":10,\"uuid\":\"uuid310\"},{\"x\":211.94,\"y\":57,\"label\":\"4\",\"categoryLabel\":\"Cat2\",\"categoryAccessible\":false,\"categoryKey\":10,\"uuid\":\"uuid311\"},{\"x\":231.94,\"y\":57,\"label\":\"5\",\"categoryLabel\":\"Cat2\",\"categoryAccessible\":false,\"categoryKey\":10,\"uuid\":\"uuid312\"},{\"x\":251.94,\"y\":57,\"label\":\"6\",\"categoryLabel\":\"Cat2\",\"categoryAccessible\":false,\"categoryKey\":10,\"uuid\":\"uuid313\"},{\"x\":271.94,\"y\":57,\"label\":\"7\",\"categoryLabel\":\"Cat2\",\"categoryAccessible\":false,\"categoryKey\":10,\"uuid\":\"uuid314\"},{\"x\":291.94,\"y\":57,\"label\":\"8\",\"categoryLabel\":\"Cat2\",\"categoryAccessible\":false,\"categoryKey\":10,\"uuid\":\"uuid315\"}],\"curve\":0,\"chairSpacing\":4,\"objectType\":\"row\",\"uuid\":\"uuid317\"},{\"label\":\"D\",\"seatLabeling\":{\"algoName\":\"SimpleNumbers\",\"startAtIndex\":0,\"isInverted\":false},\"objectLabeling\":{\"algoName\":\"SimpleLettersUppercase\",\"prefix\":\"\",\"startAtIndex\":0},\"seats\":[{\"x\":151.94,\"y\":81,\"label\":\"1\",\"categoryLabel\":\"Cat2\",\"categoryAccessible\":false,\"categoryKey\":10,\"uuid\":\"uuid318\"},{\"x\":171.94,\"y\":81,\"label\":\"2\",\"categoryLabel\":\"Cat2\",\"categoryAccessible\":false,\"categoryKey\":10,\"uuid\":\"uuid319\"},{\"x\":191.94,\"y\":81,\"label\":\"3\",\"categoryLabel\":\"Cat2\",\"categoryAccessible\":false,\"categoryKey\":10,\"uuid\":\"uuid320\"},{\"x\":211.94,\"y\":81,\"label\":\"4\",\"categoryLabel\":\"Cat2\",\"categoryAccessible\":false,\"categoryKey\":10,\"uuid\":\"uuid321\"},{\"x\":231.94,\"y\":81,\"label\":\"5\",\"categoryLabel\":\"Cat2\",\"categoryAccessible\":false,\"categoryKey\":10,\"uuid\":\"uuid322\"},{\"x\":251.94,\"y\":81,\"label\":\"6\",\"categoryLabel\":\"Cat2\",\"categoryAccessible\":false,\"categoryKey\":10,\"uuid\":\"uuid323\"},{\"x\":271.94,\"y\":81,\"label\":\"7\",\"categoryLabel\":\"Cat2\",\"categoryAccessible\":false,\"categoryKey\":10,\"uuid\":\"uuid324\"},{\"x\":291.94,\"y\":81,\"label\":\"8\",\"categoryLabel\":\"Cat2\",\"categoryAccessible\":false,\"categoryKey\":10,\"uuid\":\"uuid325\"}],\"curve\":0,\"chairSpacing\":4,\"objectType\":\"row\",\"uuid\":\"uuid327\"}],\"shapes\":[],\"booths\":[],\"generalAdmissionAreas\":[{\"categoryLabel\":\"Cat1\",\"categoryKey\":9,\"capacity\":100,\"label\":\"GA1\",\"labelSize\":24,\"labelShown\":true,\"labelHorizontalOffset\":0,\"labelVerticalOffset\":0,\"objectType\":\"generalAdmission\",\"uuid\":\"uuid368\",\"type\":\"circle\",\"center\":{\"x\":53.22,\"y\":48.89},\"rotationAngle\":0,\"radius1\":52.222222222222626,\"radius2\":45.55555555555566},{\"categoryLabel\":\"Cat2\",\"categoryKey\":10,\"capacity\":100,\"label\":\"GA2\",\"labelSize\":24,\"labelShown\":true,\"labelHorizontalOffset\":0,\"labelVerticalOffset\":0,\"objectType\":\"generalAdmission\",\"uuid\":\"uuid369\",\"type\":\"circle\",\"center\":{\"x\":389.22,\"y\":48.89},\"rotationAngle\":0,\"radius1\":52.222222222222626,\"radius2\":45.55555555555566}],\"sections\":[],\"focalPoint\":{\"x\":223.89,\"y\":42.67},\"snapOffset\":{\"x\":0.06,\"y\":3}}}";
        }
    }
}