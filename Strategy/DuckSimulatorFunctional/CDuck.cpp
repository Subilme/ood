#include <iostream>
#include <functional>

#include "DanceMenuet.h"
#include "DanceNoWay.h"
#include "DanceWaltz.h"
#include "FlyNoWay.h"
#include "FlyWithWings.h"
#include "MuteQuackBehavior.h"
#include "QuackBehavior.h"
#include "SqueakBehavior.h"

class CDuck
{
public:
	CDuck(std::function<void()>&& flyBehavior, std::function<void()>&& quackBehavior, std::function<void()>&& danceBehavior)
		: m_quackBehavior(std::move(quackBehavior))
	{
		SetFlyBehavior(move(flyBehavior));
		SetDanceBehavior(move(danceBehavior));
	}

	void Quack() const
	{
		m_quackBehavior();
	}

	void Fly() const
	{
		m_flyBehavior();
	}

	void Dance() const
	{
		m_danceBehavior();
	}

	void Swim() const
	{
		std::cout << "I`m swimming" << std::endl;
	}

	void SetFlyBehavior(std::function<void()>&& flyBehavior)
	{
		m_flyBehavior = std::move(flyBehavior);
	}

	void SetDanceBehavior(std::function<void()>&& danceBehavior)
	{
		m_danceBehavior = std::move(danceBehavior);
	}

	virtual void Display() const = 0;

	virtual ~CDuck() = default;

private:
	std::function<void()> m_flyBehavior;
	std::function<void()> m_quackBehavior;
	std::function<void()> m_danceBehavior;
};

class CDecoyDuck : public CDuck
{
public:
	CDecoyDuck()
		:CDuck(flyWithWings, quack, danceNoWay)
	{
	}

	void Display() const override
	{
		std::cout << "I`m decoy duck" << std::endl;
	}
};

class CMallardDuck : public CDuck
{
public:
	CMallardDuck()
		:CDuck(flyWithWings, quack, danceWaltz)
	{
	}

	void Display() const override
	{
		std::cout << "I`m mallard duck" << std::endl;
	}
};

class CRedheadDuck : public CDuck
{
public:
	CRedheadDuck()
		:CDuck(flyWithWings, squeak, danceMinuet)
	{
	}

	void Display() const override
	{
		std::cout << "I`m redhead duck" << std::endl;
	}
};

class CRubberDuck : public CDuck
{
public:
	CRubberDuck()
		:CDuck(flyWithWings, quack, danceNoWay)
	{
	}

	void Display() const override
	{
		std::cout << "I`m rubber duck" << std::endl;
	}
};