#define READY_FOR_CONNECTION 'A'
#define MSG_OK 1
#define MSG_INFO 2


struct message
{
	int msgType;
	union {
		struct info
		{
			unsigned long timestamp;
			char battery;
		};
	} data;
};